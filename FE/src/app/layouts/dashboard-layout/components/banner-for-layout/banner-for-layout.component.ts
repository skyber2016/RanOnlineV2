import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { LoginPageComponent } from "src/app/pages/login-page/login-page.component";
import { GlobalSettingService } from "src/app/services/global-setting.service";
@Component({
  selector: "app-banner-for-layout",
  templateUrl: "./banner-for-layout.component.html",
  styleUrls: ["./banner-for-layout.component.scss"],
})
export class BannerForLayoutComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private setting: GlobalSettingService
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
}
