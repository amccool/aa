import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-facilities',
  templateUrl: './facilities.component.html'
})
export class FacilitiesComponent {
  //public forecasts: WeatherForecast[];
  public facilities: Facility[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Facility[]>(baseUrl + 'api/Facility/FacilitiesList').subscribe(result => {
      this.facilities = result;
    }, error => console.error(error));
  }
}

interface Facility {
  FacilityId: string;
  Active: boolean;
  FacilityName: string;
}
