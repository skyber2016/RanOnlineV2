import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { LoginPageComponent } from "src/app/pages/login-page/login-page.component";
import { GlobalSettingService } from "src/app/services/global-setting.service";
import { CardPageComponent } from "src/app/pages/card-page/card-page.component";
import { AuthService } from "src/app/services/auth.service";
@Component({
  selector: "app-banner-for-layout",
  templateUrl: "./banner-for-layout.component.html",
  styleUrls: ["./banner-for-layout.component.scss"],
})
export class BannerForLayoutComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private setting: GlobalSettingService,
    private authService: AuthService
  ) {}
  ngOnInit(): void {
    this.setting.GlobalSetting.then((result) => {
      this.settings = result;
    });
  }
  settings: any = {};
  login() {
    const dialogRef = this.dialog.open(LoginPageComponent, {
      data: {},
    });
    dialogRef.afterClosed().subscribe((result) => {});
  }
  card() {
    if (this.authService.isLogin()) {
      const dialogRef = this.dialog.open(CardPageComponent, {
        data: {},
      });
      dialogRef.afterClosed().subscribe((result) => {});
    } else {
      this.login();
    }
  }
}
