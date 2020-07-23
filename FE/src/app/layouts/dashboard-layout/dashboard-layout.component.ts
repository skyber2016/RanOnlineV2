import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-dashboard-layout",
  templateUrl: "./dashboard-layout.component.html",
  styleUrls: ["./dashboard-layout.component.scss"],
})
export class DashboardLayoutComponent implements OnInit {
  fullName = "";
  constructor() {}

  ngOnInit(): void {
    this.fullName = window.localStorage.getItem("username");
  }
  logout() {
    window.localStorage.clear();
    this.fullName = window.localStorage.getItem("username");
  }
}
