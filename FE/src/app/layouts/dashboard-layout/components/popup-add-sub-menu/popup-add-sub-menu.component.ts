import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  Inject,
} from "@angular/core";
import { MenuService } from "src/app/services/menu.service";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ok } from "assert";

@Component({
  selector: "app-popup-add-sub-menu",
  templateUrl: "./popup-add-sub-menu.component.html",
  styleUrls: ["./popup-add-sub-menu.component.scss"],
})
export class PopupAddSubMenuComponent implements OnInit {
  @ViewChild("name") name: ElementRef;
  @ViewChild("url") url: ElementRef;
  constructor(
    private menuService: MenuService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<PopupAddSubMenuComponent>
  ) {}

  ngOnInit(): void {}

  save() {
    const nameMenu = this.name.nativeElement.value;
    const urlMenu = this.url.nativeElement.value;
    if (nameMenu) {
      this.menuService
        .create({
          parentId: this.data.parentId,
          name: nameMenu,
          url: urlMenu,
        })
        .then((res) => {
          this.dialogRef.close();
        });
    }
  }
}
