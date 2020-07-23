import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  Inject,
} from "@angular/core";
import { AuthService } from "src/app/services/auth.service";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { SpinnerService } from "src/app/services/spinner.service";

@Component({
  selector: "app-login-page",
  templateUrl: "./login-page.component.html",
  styleUrls: ["./login-page.component.scss"],
})
export class LoginPageComponent implements OnInit {
  @ViewChild("username") username: ElementRef;
  @ViewChild("password") password: ElementRef;
  message = "";
  constructor(
    private authService: AuthService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<LoginPageComponent>,
    private router: Router,
    private spinner: SpinnerService
  ) {}

  ngOnInit(): void {}
  login() {
    var un = this.username.nativeElement.value;
    var pass = this.password.nativeElement.value;
    if (!un || !pass) {
      return;
    }
    this.spinner.show();
    this.authService
      .login({ username: un, password: pass })
      .then((result) => {
        window.localStorage.setItem("token", result.token);
        window.localStorage.setItem("username", un);
        window.location.reload();
      })
      .catch((message) => {
        this.message = message;
        this.spinner.hidden();
      });
  }
}
