import {
  ActionReducerMap,
  createSelector,
  createFeatureSelector,
  ActionReducer,
  MetaReducer,
} from "@ngrx/store";
import { RouterStateUrl } from "../../shared/utils/router-utils";
import * as fromRouter from "@ngrx/router-store";
import * as fromCore from "./core";
import { environment } from "src/environments/environment";


export interface State {
  routerReducer: fromRouter.RouterReducerState<RouterStateUrl>;
}


export const reducers: ActionReducerMap<State> = {
  routerReducer: fromRouter.routerReducer
};

// console.log all actions & state
export function logger(reducer: ActionReducer<State>): ActionReducer<State> {
  return function(state: State, action: any): State {
    console.log("state", state);
    console.log("action", action);

    return reducer(state, action);
  };
}

/**
 * MetReducer such as logger
 */
export const metaReducers: MetaReducer<State>[] = !environment.production
  ? [logger]
  : [];

export const getRouterState = createFeatureSelector<State>("routerReducer");
export const getRouteUrl = createSelector(
  getRouterState,
  (routerReducerState) => routerReducerState.routerReducer.state.url);

/**
 * Core Reducers
 */
export const getCoreState = createFeatureSelector<fromCore.State>("core");

export const getCartCount = createSelector(
  getCoreState,
  fromCore.getCount
);

export const getCartTotal = createSelector(
  getCoreState,
  fromCore.getTotal
);
