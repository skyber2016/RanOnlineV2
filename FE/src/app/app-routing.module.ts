import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomePageComponent } from "./pages/home-page/home-page.component";
import { DashboardLayoutComponent } from "./layouts/dashboard-layout/dashboard-layout.component";
import { NewsPageComponent } from "./pages/news-page/news-page.component";
import { NewsDetailPageComponent } from "./pages/news-detail-page/news-detail-page.component";
import { NewsEditorPageComponent } from "./pages/news-editor-page/news-editor-page.component";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { LandingPageComponent } from "./pages/landing-page/landing-page.component";
import { LocationStrategy, HashLocationStrategy } from "@angular/common";

const routes: Routes = [
  {
    path: "",
    component: LandingPageComponent,
  },
  {
    path: "home",
    component: DashboardLayoutComponent,
    children: [
      {
        path: "",
        component: NewsPageComponent,
      },
      {
        path: "news/:id/:title",
        component: NewsDetailPageComponent,
      },
    ],
  },
  {
    path: "login",
    component: LoginPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
