import { Component, OnInit } from "@angular/core";
import { SpinnerService } from "src/app/services/spinner.service";
import { RankingService } from "src/app/services/ranking.service";

@Component({
  selector: "app-session-right-for-layout",
  templateUrl: "./session-right-for-layout.component.html",
  styleUrls: ["./session-right-for-layout.component.scss"],
})
export class SessionRightForLayoutComponent implements OnInit {
  constructor(
    private spinner: SpinnerService,
    private rankingService: RankingService
  ) {}
  ranking: any[] = [];
  ngOnInit(): void {
    this.spinner.show();
    this.rankingService
      .getRanking()
      .then((result) => {
        this.ranking = result;
        this.spinner.hidden();
      })
      .catch((error) => this.spinner.hidden());
  }
}
