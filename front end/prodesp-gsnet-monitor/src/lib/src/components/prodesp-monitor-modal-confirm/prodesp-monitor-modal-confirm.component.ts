import { IModal } from 'prodesp-ui';
import { Component, OnInit } from '@angular/core';
import { ModalComponent } from '../../models/modal.component.model';
import { DialogService } from 'ng2-bootstrap-modal/dist/dialog.service';
export interface IModalMonitorConfirm extends IModal {
  text: string;
}
@Component({
  selector: 'prodesp-monitor-modal-confirm',
  templateUrl: './prodesp-monitor-modal-confirm.component.html',
  styleUrls: ['./prodesp-monitor-modal-confirm.component.css']
})
export class ProdespMonitorModalConfirmComponent extends ModalComponent<IModalMonitorConfirm> implements OnInit {

  constructor(dialogService: DialogService) {
    super(dialogService);
  }

  ngOnInit() {
  }
  confirm(data: any): void {
    this.result = true;
    this.close();
  }
}
