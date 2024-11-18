import { Component, inject } from '@angular/core';
import { ShopService } from '../../../core/services/shop.service';
import { MatListOption, MatSelectionList } from '@angular/material/list';
import { MatButton } from '@angular/material/button';
import { MatDivider } from '@angular/material/divider';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-filter-dialog',
  standalone: true,
  imports: [MatListOption,MatSelectionList,MatButton,MatDivider,FormsModule],
  templateUrl: './filter-dialog.component.html',
  styleUrl: './filter-dialog.component.scss'
})
export class FilterDialogComponent {
shopService = inject(ShopService)
private dialogRef = inject(MatDialogRef<FilterDialogComponent>);
data = inject(MAT_DIALOG_DATA);

selectedBrands:string[] = this.data.selectedBrands;
selectedTypes:string[] = this.data.selectedTypes;

applyFilter(){
  this.dialogRef.close({
    selectedBrands:this.selectedBrands,
    selectedTypes:this.selectedTypes
  });
}
}
