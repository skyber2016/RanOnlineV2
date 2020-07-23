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
    this.newsService.getCategory({}).then((result) => {
      this.categories = result.map((x, index) => {
        x.isActive = index == 0;
        if (x.isActive) {
          this.currentCategory = x.id;
        }
        return x;
      });
      if (this.categories.length > 0) {
        this.getNews(this.categories[0].id);
      }
    });
  }

  getNews(categoryId) {
    this.spinner.show();
    this.newsService
      .getNews({
        currentPage: this.currentPage++,
        categoryId,
      })
      .then((response) => {
        this.spinner.hidden();
        this.news = this.news.concat(response);
        console.log(this);
      })
      .catch(console.log);
  }

  viewMore() {
    this.getNews(this.currentCategory);
  }
  categoryClick(item) {
    this.currentPage = 1;
    this.currentCategory = item.id;
    this.categories = this.categories.map((x) => {
      x.isActive = x.id == item.id;
      return x;
    });
    this.news = [];
    this.getNews(this.currentCategory);
  }
}
