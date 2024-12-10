import { Component } from '@angular/core';
import { MatStepper, MatStepperModule } from '@angular/material/stepper';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [MatStepperModule,MatStepper],
  templateUrl: './test.component.html',
  styleUrl: './test.component.scss'
})
export class TestComponent {

}
