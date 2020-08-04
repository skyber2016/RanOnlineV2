import { Component, OnInit } from "@angular/core";
import { GlobalSettingService } from "src/app/services/global-setting.service";

@Component({
  selector: "app-dashboard-layout",
  templateUrl: "./dashboard-layout.component.html",
  styleUrls: ["./dashboard-layout.component.scss"],
})
export class DashboardLayoutComponent implements OnInit {
  fullName = "";
  settings: any = {};
  constructor(private setting: GlobalSettingService) {}

  ngOnInit(): void {
    this.setting.GlobalSetting.then((result) => {
      console.log(result);
      this.settings = result;
    });
    this.fullName = window.localStorage.getItem("username");
  }
  logout() {
    window.localStorage.clear();
    this.fullName = window.localStorage.getItem("username");
  }

  getBG() {
    return `url('${this.settings.background}') no-repeat top center;`;
  }
}
