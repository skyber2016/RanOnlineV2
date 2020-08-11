import { BrowserModule } from "@angular/platform-browser";
import { NgModule, InjectionToken } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomePageComponent } from "./pages/home-page/home-page.component";
import { DashboardLayoutComponent } from "./layouts/dashboard-layout/dashboard-layout.component";
import { NewsPageComponent } from "./pages/news-page/news-page.component";
import { BannerForLayoutComponent } from "./layouts/dashboard-layout/components/banner-for-layout/banner-for-layout.component";
import { SessionRightForLayoutComponent } from "./layouts/dashboard-layout/components/session-right-for-layout/session-right-for-layout.component";
import { MenuForLayoutComponent } from "./layouts/dashboard-layout/components/menu-for-layout/menu-for-layout.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { PopupAddMenuComponent } from "./layouts/dashboard-layout/components/popup-add-menu/popup-add-menu.component";
import { PopupAddSubMenuComponent } from "./layouts/dashboard-layout/components/popup-add-sub-menu/popup-add-sub-menu.component";
import { MatDialog, MatDialogModule } from "@angular/material/dialog";
import { NewsDetailPageComponent } from "./pages/news-detail-page/news-detail-page.component";
import { CKEditorModule } from "ckeditor4-angular";
import { NewsEditorPageComponent } from "./pages/news-editor-page/news-editor-page.component";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { LandingPageComponent } from "./pages/landing-page/landing-page.component";
import { CardPageComponent } from "./pages/card-page/card-page.component";
@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    DashboardLayoutComponent,
    NewsPageComponent,
    BannerForLayoutComponent,
    SessionRightForLayoutComponent,
    MenuForLayoutComponent,
    PopupAddMenuComponent,
    PopupAddSubMenuComponent,
    NewsDetailPageComponent,
    NewsEditorPageComponent,
    LoginPageComponent,
    LandingPageComponent,
    CardPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
    CKEditorModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    PopupAddSubMenuComponent,
    LoginPageComponent,
    CardPageComponent,
  ],
})
export class AppModule {}
