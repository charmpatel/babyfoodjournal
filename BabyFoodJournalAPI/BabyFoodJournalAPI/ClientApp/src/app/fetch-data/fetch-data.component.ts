import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public foodEntries: BabyFoodJournal[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'babyfoodjournal').subscribe(result => {
      this.foodEntries = result;
    }, error => console.error(error));
  }
}

interface BabyFoodJournal {
  Date: string;
  Notes: string;
  FoodEntry: string;
  CreatedAt: string;
  UpdatedAt: string;
}
