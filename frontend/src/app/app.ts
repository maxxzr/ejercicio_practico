import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from "./shared/header/header";
import { Menu } from "./shared/menu/menu";
import { Toast } from "./shared/toast/toast";
import { Loading } from "./shared/loading/loading";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Menu, Toast, Loading],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('frontend');
}
