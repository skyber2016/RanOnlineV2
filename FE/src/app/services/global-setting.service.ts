import { Injectable } from '@angular/core';
import { http } from "../common/interceptor";
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class GlobalSettingService {

  public GlobalSetting: Promise<any>;
  constructor() { 
    this.GlobalSetting = this.getSetting();
  }

  getSetting(): Promise<any>{
    return http.get(environment.host + "/setting");
  }
}
