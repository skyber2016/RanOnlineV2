import { Component, OnInit } from "@angular/core";
import { NewsService } from "src/app/services/news.service";
import { SpinnerService } from "src/app/services/spinner.service";

@Component({
  selector: "app-news-page",
  templateUrl: "./news-page.component.html",
  styleUrls: ["./news-page.component.scss"],
})
export class NewsPageComponent implements OnInit {
  categories = [];
  news = [];
  currentPage = 1;
  currentCategory = -1;
  constructor(
    private newsService: NewsService,
    private spinner: SpinnerService
  ) {}

  ngOnInit(): void {
    this.spinner.show();
    this.getNews();
  }

  getNews() {
    this.spinner.show();
    this.newsService
      .getNews({
        currentPage: this.currentPage++,
      })
      .then((response) => {
        this.spinner.hidden();
        this.news = this.news.concat(response);
        console.log(response);
      })
      .catch(console.log);
  }

  viewMore() {
    this.getNews();
  }
}
