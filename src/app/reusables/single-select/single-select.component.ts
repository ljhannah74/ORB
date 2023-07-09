import { CdkVirtualScrollViewport } from '@angular/cdk/scrolling';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, QueryList, SimpleChanges, ViewChild, ViewChildren } from '@angular/core';
import { MatOptionSelectionChange } from '@angular/material/core';
import { MatSelect } from '@angular/material/select';

@Component({
    selector: 'single-select',
    templateUrl: './single-select.component.html',
    styleUrls: ['./single-select.component.scss']
})
export class SingleSelectComponent implements OnInit, OnChanges {
    @Input() id?: string;
    @Input() disabled = false;
    @Input() search = true;
    @Input() placeholder = "";
    @Input() value: any;
    @Input() options: any[] = [];
    @Input() autoWidth = false;
    @Input() isLoading = false;
    @Input() primaryKey = "";
    @Input() label = "";
    @Input() selectionText?: string;
    @Input() caption = "";

    @Output() opened = new EventEmitter<void>();
    @Output() closed = new EventEmitter<void>();
    @Output() valueChange = new EventEmitter<any>();

    @ViewChild(MatSelect) matSelectComponent?: MatSelect;

    @ViewChildren(CdkVirtualScrollViewport) cdkVirtualScrollViewPorts?: QueryList<CdkVirtualScrollViewport>;

    filterText = '';

    constructor(
    ) { }

    ngOnInit() {
    }

    ngOnChanges(changes: SimpleChanges) {
        let hasSetupValues = false;
    }

    closeDropdown() {
      this.matSelectComponent?.close();
    }

    onOpen() {
        // virtual scroll won't render properly without triggering a scroll to the top
        this.cdkVirtualScrollViewPorts?.forEach(viewport => {
            viewport.scrollToIndex(1);
            viewport.scrollToIndex(0);
            viewport.checkViewportSize();
        });

        this.opened.emit();
    }

    onClose() {
        this.closed.emit();
    }

    onMatSelectChange(change: MatOptionSelectionChange) {
        if (!change.isUserInput)
            return;

        const id: number = change.source.value;
        this.value = id;
        this.valueChange.emit(this.value);
    }
}

