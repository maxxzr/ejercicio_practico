import { Injectable } from '@angular/core';

interface ToastMessage{
  message:string;
  type:string;
}
@Injectable({
  providedIn: 'root',
})
export class ToastService {
  toasts: ToastMessage[] = [];

  private push(toastMessage:ToastMessage){
    toastMessage.message = toastMessage.message.replace(/\n/g, '<br/>');
    this.toasts.push(toastMessage);
  }
  add(message: string) {
    this.push({message:message,type:'default'});
  }

  addSuccess(message: string) {
    this.push({message:message,type:'success'});
  }

  addInfo(message: string) {
    this.push({message:message,type:'info'});
  }

  addError(message: string) {
    this.push({message:message,type:'error'});
  }

  showError(error: any) {
    let message = error.error?.message || error.message || error.toString() || 'Error desconocido';
    this.push({message:message,type:'error'});
  }

  remove(index: number) {
    this.toasts.splice(index, 1);
  }
}