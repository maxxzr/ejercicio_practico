import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class LoadingService{
    show: boolean = false;

    showLoading() {
        this.show = true;
    }

    hideLoading() {
        this.show = false;
    }
}