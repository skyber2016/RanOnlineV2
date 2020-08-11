import { Component, OnInit, ElementRef, ViewChild } from "@angular/core";
import { SpinnerService } from "src/app/services/spinner.service";
import { CardService } from "src/app/services/card.service";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector: "app-card-page",
  templateUrl: "./card-page.component.html",
  styleUrls: ["./card-page.component.scss"],
})
export class CardPageComponent implements OnInit {
  constructor(
    private spinner: SpinnerService,
    private cardService: CardService
  ) {}
  @ViewChild("telco") telco: ElementRef;
  @ViewChild("amount") amount: ElementRef;
  @ViewChild("seri") seri: ElementRef;
  @ViewChild("code") code: ElementRef;
  message = "";
  ngOnInit(): void {}
  card() {
    if (
      !this.telco.nativeElement.value ||
      !this.amount.nativeElement.value ||
      !this.seri.nativeElement.value ||
      !this.code.nativeElement.value
    ) {
      return;
    }
    this.spinner.show();
    this.cardService
      .postCard({
        telco: this.telco.nativeElement.value,
        amount: this.amount.nativeElement.value,
        serial: this.seri.nativeElement.value,
        code: this.code.nativeElement.value,
      })
      .then((result) => {
        this.message = "Nạp thẻ thành công!";
        this.spinner.hidden();
      })
      .catch((message) => {
        this.message = message;
        this.spinner.hidden();
      });
  }
}
