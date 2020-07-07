import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class SpinnerService {
  constructor() {}

  show() {
    const loader = document.getElementById("loader");
    loader.style.display = "block";
  }
  hidden() {
    const loader = document.getElementById("loader");
    loader.style.display = "none";
  }
}
