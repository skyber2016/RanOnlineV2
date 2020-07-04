import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { menuData } from "../common/Data";

@Injectable({
  providedIn: "root",
})
export class MenuService {
  constructor() {}

  getMenu(): Observable<any[]> {
    return of(menuData);
  }
}
