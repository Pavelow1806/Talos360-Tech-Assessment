import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-scrollable',
  templateUrl: './scrollable.component.html',
  styleUrls: ['./scrollable.component.scss']
})
export class ScrollableComponent {
  @Input("contentCentered") contentCentered = true;
}
