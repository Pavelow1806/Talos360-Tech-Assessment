import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-header-item',
  templateUrl: './header-item.component.html',
  styleUrls: ['./header-item.component.scss']
})
export class ItemComponent {
  @Input("icon") icon = "";
  @Input("url") url = "";
  @Input("notifications") notifications = 0;
}
