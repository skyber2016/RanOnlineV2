import { Component, OnInit } from "@angular/core";
import { MenuService } from "src/app/services/menu.service";
import { MatDialogModule, MatDialog } from "@angular/material/dialog";
import { PopupAddSubMenuComponent } from "../popup-add-sub-menu/popup-add-sub-menu.component";
import { SpinnerService } from "src/app/services/spinner.service";
@Component({
  selector: "app-menu-for-layout",
  templateUrl: "./menu-for-layout.component.html",
  styleUrls: ["./menu-for-layout.component.scss"],
})
export class MenuForLayoutComponent implements OnInit {
  menuLeft = [];
  menuRight = [];
  constructor(
    private menuService: MenuService,
    public dialog: MatDialog,
    private spinner: SpinnerService
  ) {}

  ngOnInit(): void {
    this.initMenu();
  }
  initMenu() {
    this.spinner.show();
    this.menuLeft = [];
    this.menuRight = [];
    const menuData = this.menuService.getMenu().then((cate) => {
      for (let index = 0; index < cate.length / 2; index++) {
        this.menuLeft.push(cate[index]);
      }
      for (let index = cate.length / 2; index < cate.length; index++) {
        this.menuRight.push(cate[index]);
      }
      this.spinner.hidden();
    });
  }
  deleteSubMenu(item) {
    this.menuService.delete(item.id).then((res) => {
      this.initMenu();
    });
  }
  addSubMenu(item) {
    const parentId = item.id;
    this.openDialog(parentId);
  }
  openDialog(id) {
    const dialogRef = this.dialog.open(PopupAddSubMenuComponent, {
      data: {
        parentId: id,
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      this.initMenu();
    });
  }
}
