import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomePageComponent } from "./pages/home-page/home-page.component";
import { DashboardLayoutComponent } from "./layouts/dashboard-layout/dashboard-layout.component";

const routes: Routes = [
  {
    path: "",
    component: DashboardLayoutComponent,
    children: [
      {
        path: "",
        component: HomePageComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
