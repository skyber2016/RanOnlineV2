import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { SpinnerService } from "src/app/services/spinner.service";
import { NewsService } from "src/app/services/news.service";
@Component({
  selector: "app-news-detail-page",
  templateUrl: "./news-detail-page.component.html",
  styleUrls: ["./news-detail-page.component.scss"],
})
export class NewsDetailPageComponent implements OnInit {
  news: any;
  constructor(
    private router: ActivatedRoute,
    private spinner: SpinnerService,
    private newsService: NewsService
  ) {}

  ngOnInit(): void {
    this.router.paramMap.subscribe((params) => {
      const newsId = params.get("id");
      if (newsId) {
        this.spinner.show();
        this.newsService
          .getNewsDetail({ id: newsId })
          .then((response) => {
            this.news = response;
            window.scrollTo(-10, -10);
            this.spinner.hidden();
          })
          .catch(console.log);
      }
    });
    // this.router.events.subscribe((val) => console.log(val));
  }
}
