import { Injectable } from "@angular/core";
import { http } from "../common/interceptor";
import { environment } from "src/environments/environment";
import { config } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class NewsService {
  constructor() {}

  getCategory(param): Promise<any[]> {
    return http.get(environment.host + "/category", {
      params: param,
    });
  }

  getNews(param): Promise<any[]> {
    return http.get(environment.host + "/news", {
      params: param,
    });
  }

  getNewsDetail(param): Promise<any[]> {
    return http.get(environment.host + "/news/detail", {
      params: param,
    });
  }
}
