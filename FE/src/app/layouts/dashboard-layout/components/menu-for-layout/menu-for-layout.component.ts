import { Component, OnInit, SimpleChanges } from "@angular/core";
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
  fullName = "";
  constructor(
    private menuService: MenuService,
    public dialog: MatDialog,
    private spinner: SpinnerService
  ) {}

  ngOnInit(): void {
    this.initMenu();
    this.fullName = window.localStorage.getItem("username");
  }
  ngOnChanges(changes: SimpleChanges): void {
    this.fullName = window.localStorage.getItem("username");
  }
  initMenu() {
    this.spinner.show();
    this.menuLeft = [];
    this.menuRight = [];
    this.menuService.getMenu().then((cate) => {
      for (let index = 0; index < cate.length / 2; index++) {
        this.menuLeft.push(cate[index]);
      }
      for (let index = cate.length / 2; index < cate.length; index++) {
        this.menuRight.push(cate[index]);
      }
      for (let index = this.menuLeft.length; index < 4; index++) {
        this.menuLeft.push({ id: -1, name: "" });
      }
      for (let index = this.menuRight.length; index < 4; index++) {
        this.menuRight.push({ id: -1, name: "" });
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
