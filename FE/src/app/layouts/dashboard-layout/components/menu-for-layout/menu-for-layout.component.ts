import { Component, OnInit } from "@angular/core";
import { MenuService } from "src/app/services/menu.service";

@Component({
  selector: "app-menu-for-layout",
  templateUrl: "./menu-for-layout.component.html",
  styleUrls: ["./menu-for-layout.component.scss"],
})
export class MenuForLayoutComponent implements OnInit {
  menuLeft = [];
  menuRight = [];
  constructor(private menuService: MenuService) {}

  ngOnInit(): void {
    const menuData = this.menuService.getMenu().subscribe((cate) => {
      for (let index = 0; index < cate.length / 2; index++) {
        this.menuLeft.push(cate[index]);
      }
      for (let index = cate.length / 2; index < cate.length; index++) {
        this.menuRight.push(cate[index]);
      }
      console.log(this.menuLeft, this.menuRight);
    });
  }
}
