import { Injectable } from "@angular/core";
import { http } from "../common/interceptor";
import { environment } from "src/environments/environment";
import { config } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class NewsService {
  constructor() {}

  getCategories(): Promise<any[]> {
    return http.get(environment.host + "/category");
  }

  getNews(param): Promise<any[]> {
    return http.get(environment.host + "/category/news", {
      params: param,
    });
  }
}
