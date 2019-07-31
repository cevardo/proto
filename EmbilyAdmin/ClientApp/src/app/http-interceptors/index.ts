/* "Barrel" of Http Interceptors */
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { LoggingInterceptor } from './logging-interceptor';
import { NotifyInterceptor } from './notify-interceptor';
//import { AuthInterceptor } from './auth-interceptor';
//import { CachingInterceptor } from './caching-interceptor';
//import { EnsureHttpsInterceptor } from './ensure-https-interceptor';
//import { NoopInterceptor } from './noop-interceptor';
//import { TrimNameInterceptor } from './trim-name-interceptor';
//import { UploadInterceptor } from './upload-interceptor';


/** Http interceptor providers in outside-in order */
export const httpInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: LoggingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: NotifyInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: NoopInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: EnsureHttpsInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: TrimNameInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: UploadInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: CachingInterceptor, multi: true },
];

export const httpInterceptorProvidersProd = [
    //{ provide: HTTP_INTERCEPTORS, useClass: LoggingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: NotifyInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: NoopInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: EnsureHttpsInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: TrimNameInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: UploadInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: CachingInterceptor, multi: true },
];
