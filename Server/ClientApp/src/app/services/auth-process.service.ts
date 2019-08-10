import { EventEmitter, Inject, Injectable, forwardRef } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { ICredentials, ISignInProcess, ISignUpProcess } from '../interfaces/main.interface';
import { NgxAuthFirebaseUIConfig } from '../interfaces/config.interface';
import { Accounts } from '../enums';

// import User = firebase.User;


import { NgxAuthFirebaseUIConfigToken } from '../login/login.module';

export const facebookAuthProvider = {};
export const googleAuthProvider = {};
export const twitterAuthProvider = {};
export const githubAuthProvider = {};
export const microsoftAuthProvider = {};
export const yahooAuthProvider = {};

export enum AuthProvider {
	ALL = 'all',
	ANONYMOUS = 'anonymous',
	EmailAndPassword = 'firebase',
	Google = 'google',
	Facebook = 'facebook',
	Twitter = 'twitter',
	Github = 'github',
	Microsoft = 'microsoft',
	Yahoo = 'yahoo',
	PhoneNumber = 'phoneNumber'
}

@Injectable()
export class AuthProcessService implements ISignInProcess, ISignUpProcess {
	onSuccessEmitter: EventEmitter<any> = new EventEmitter<any>();
	onErrorEmitter: EventEmitter<any> = new EventEmitter<any>();

	isLoading: boolean;
	emailConfirmationSent: boolean;

	emailToConfirm: string;
	messageOnAuthSuccess: string;
	messageOnAuthError: string;

	private _fireStoreService: any;
	public afa: any;

	constructor(
		private _snackBar: MatSnackBar,
		@Inject(forwardRef(() => NgxAuthFirebaseUIConfigToken)) public config: NgxAuthFirebaseUIConfig
	) { }

	/**
	 * Reset the password of the ngx-auth-firebaseui-user via email
	 *
	 * @param email - the email to reset
	 * @returns
	 */
	public resetPassword(email: string) {
		return this.afa.auth.sendPasswordResetEmail(email)
			.then(() => console.log('email sent'))
			.catch((error) => this.onErrorEmitter.next(error));
	}

	/**
	 * General sign in mechanism to authenticate the users with a firebase project
	 * using a traditional way, via username and password or by using an authentication provider
	 * like google, facebook, twitter and github
	 *
	 * @param provider - the provider to authenticate with (google, facebook, twitter, github)
	 * @param credentials
	 * @returns
	 */
	public async signInWith(provider: AuthProvider, credentials?: ICredentials) {
		console.log('this.config on signInWith', this.config);
		try {
			this.isLoading = true;
			let signInResult: any;

			switch (provider) {
				case AuthProvider.ANONYMOUS:
					signInResult = await this.afa.auth.signInAnonymously();
					break;

				case AuthProvider.EmailAndPassword:
					signInResult = await this.afa.auth.signInWithEmailAndPassword(credentials.email, credentials.password);
					break;

				case AuthProvider.Google:
					signInResult = await this.afa.auth.signInWithPopup(googleAuthProvider);
					break;

				case AuthProvider.Facebook:
					signInResult = await this.afa.auth.signInWithPopup(facebookAuthProvider);
					break;

				case AuthProvider.Twitter:
					signInResult = await this.afa.auth.signInWithPopup(twitterAuthProvider);
					break;

				case AuthProvider.Github:
					signInResult = await this.afa.auth.signInWithPopup(githubAuthProvider);
					break;

				case AuthProvider.Microsoft:
					signInResult = await this.afa.auth.signInWithPopup(microsoftAuthProvider);
					break;

				case AuthProvider.Yahoo:
					signInResult = await this.afa.auth.signInWithPopup(yahooAuthProvider);
					break;

				case AuthProvider.PhoneNumber:
					// coming soon - see feature/sms branch
					break;

				default:
					throw new Error(`${AuthProvider[provider]} is not available as auth provider`);

			}
			await this.handleSuccess(signInResult);
		} catch (err) {
			this.handleError(err);
			console.error(err);
			// this._snackBar.open(err.message, 'OK', {duration: 5000});
			this.onErrorEmitter.next(err);
		} finally {
			this.isLoading = false;
		}
	}

	/**
	 * Sign up new users via email and password.
	 * After that the ngx-auth-firebaseui-user should verify and confirm an email sent via the firebase
	 *
	 * @param displayName - the displayName if the new ngx-auth-firebaseui-user
	 * @param credentials
	 * @returns
	 */
	public async signUp(displayName: string, credentials: ICredentials) {
		try {
			this.isLoading = true;
			const userCredential: any = await this.afa.auth.createUserWithEmailAndPassword(credentials.email, credentials.password);
			const user = userCredential.user;
			await this.updateProfile(displayName, user.photoURL);

			if (this.config.enableFirestoreSync) {
				await this._fireStoreService
					.getUserDocRefByUID(user.uid)
					.set({
						uid: user.uid,
						displayName: displayName,
						email: user.email,
						photoURL: user.photoURL
					});
			}

			await user.sendEmailVerification();
			this.emailConfirmationSent = true;
			this.emailToConfirm = credentials.email;

			await this.handleSuccess(userCredential);
		} catch (err) {
			this.handleError(err);
		} finally {
			this.isLoading = false;
		}
	}

	/**
	 * Update the profile (name + photo url) of the authenticated ngx-auth-firebaseui-user in the
	 * firebase authentication feature (not in firestore)
	 *
	 * @param name - the new name of the authenticated ngx-auth-firebaseui-user
	 * @param photoURL - the new photo url of the authenticated ngx-auth-firebaseui-user
	 * @returns
	 */
	public updateProfile(name: string, photoURL: string): Promise<any> {
		return this.afa.auth.currentUser.updateProfile({ displayName: name, photoURL: photoURL });
	}

	public deleteAccount(): Promise<any> {
		return this.afa.auth.currentUser.delete();
	}

	public parseUserInfo(user: any): any {
		return {
			uid: user.uid,
			displayName: user.displayName,
			email: user.email,
			phoneNumber: user.phoneNumber,
			photoURL: user.photoURL,
			providerId: user.providerData.length > 0 ? user.providerData[0].providerId : null
		};
	}

	public getUserPhotoUrl(): string {

		const user: any | null = this.afa.auth.currentUser;

		if (!user) {
			return;
		} else if (user.photoURL) {
			return user.photoURL;
		} else if (user.emailVerified) {
			return this.getPhotoPath(Accounts.CHECK);
		} else if (user.isAnonymous) {
			return this.getPhotoPath(Accounts.OFF);
		} else {
			return this.getPhotoPath(Accounts.NONE);
		}
	}

	public getPhotoPath(image: string) {
		return `assets/user/${image}.svg`;
	}

	public signInWithPhoneNumber() {
		// todo: 3.1.18
	}

	async handleSuccess(userCredential: any) {
		this.onSuccessEmitter.next(userCredential.user);
		if (this.config.enableFirestoreSync) {
			try {
				await this._fireStoreService.updateUserData(this.parseUserInfo(userCredential.user));
			} catch (e) {
				console.error(`Error occurred while updating user data with firestore: ${e}`);
			}
		}

		if (this.config.toastMessageOnAuthSuccess) {
			this._snackBar.open(this.messageOnAuthSuccess ? this.messageOnAuthSuccess :
				`Hello ${userCredential.user.displayName ? userCredential.user.displayName : ''}!`,
				'OK', { duration: 5000 });
		}
	}

	handleError(error: any) {
		this.onErrorEmitter.next(error);
		if (this.config.toastMessageOnAuthError) {
			this._snackBar.open(this.messageOnAuthError ? this.messageOnAuthError :
				error.message, 'OK', { duration: 5000 });
		}
		console.error(error);
	}

}