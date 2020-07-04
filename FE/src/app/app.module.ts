import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomePageComponent } from "./pages/home-page/home-page.component";
import { DashboardLayoutComponent } from "./layouts/dashboard-layout/dashboard-layout.component";
import { NewsPageComponent } from './pages/news-page/news-page.component';
import { BannerForLayoutComponent } from './layouts/dashboard-layout/components/banner-for-layout/banner-for-layout.component';
import { SessionRightForLayoutComponent } from './layouts/dashboard-layout/components/session-right-for-layout/session-right-for-layout.component';
import { MenuForLayoutComponent } from './layouts/dashboard-layout/components/menu-for-layout/menu-for-layout.component';

@NgModule({
  declarations: [AppComponent, HomePageComponent, DashboardLayoutComponent, NewsPageComponent, BannerForLayoutComponent, SessionRightForLayoutComponent, MenuForLayoutComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
