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
    this.newsService
      .getCategories()
      .then((response) => {
        this.categories = response.map((x, index) => {
          x.isActive = index == 0;
          return x;
        });
        this.spinner.hidden();
        if (this.categories.length > 0) {
          this.currentCategory = this.categories[0].id;
          this.getNews(this.currentCategory);
        }
      })
      .catch(console.log);
  }

  getNews(categoryId) {
    this.spinner.show();
    this.newsService
      .getNews({
        categoryId,
        currentPage: this.currentPage++,
      })
      .then((response) => {
        this.spinner.hidden();
        this.news = this.news.concat(response);
        console.log(response);
      })
      .catch(console.log);
  }

  categoryClick(category) {
    if (this.currentCategory == category.id) {
      return;
    }
    this.currentPage = 1;
    this.news = [];
    this.categories = this.categories.map((x) => {
      x.isActive = x.id == category.id;
      if (x.isActive) {
        this.currentCategory = x.id;
      }
      return x;
    });
    this.getNews(category.id);
  }

  viewMore() {
    this.getNews(this.currentCategory);
  }
}
