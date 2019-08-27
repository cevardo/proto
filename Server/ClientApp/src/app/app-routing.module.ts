import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";
import { LoggedInGuard } from "./guards/logged-in.guard";
import { CommentsComponent } from './comments/comments.component';
import { YtCommentsComponent } from './yt-comments/yt-comments.component';

const routes: Routes = [
    {
        path: "",
        redirectTo: "login",
        pathMatch: "full"
    },
    {
        path: "comments",
        component: CommentsComponent
    },
    {
        path: "yt-comments",
        component: YtCommentsComponent
    },
    {
        path: "dashboard",
        canActivate: [LoggedInGuard],
        loadChildren: () => import("./dashboard/dashboard.module").then(mod => mod.DashboardModule)
    },
    {
        path: "chart",
        canActivate: [LoggedInGuard],
        loadChildren: () => import("./chart/chart.module").then(mod => mod.ChartModule)
    },
    {
        path: "login",
        loadChildren: () => import("./login/login.module").then(mod => mod.LoginModule)
    },
    {
        path: "search",
        loadChildren: () => import("./search/search.module").then(mod => mod.SearchModule)
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
    exports: [RouterModule]
})
export class AppRoutingModule {}
