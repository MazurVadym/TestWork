import { APP_INITIALIZER, NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent }  from './app.component';
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { appRoutes } from "./app.routes";
import { ProductListComponent } from "./components/pages/productList/productList.component";
import { ProductListService } from "./services/productListService";
import { ConfigService } from "./services/configService";
import { ProductItemService } from "./services/productItemService";
import { EventListService } from "./services/eventListService";
import { ProductListModalComponent } from "./components/pages/productList/ProductListModal/productListModal.component";
import { ModalModule } from "ngx-bootstrap/modal";
import { LayoutComponent } from "./components/layout/layout.component";
import { ProductListResolver } from "./resolvers/productListResolver";
import { EventListComponent } from "./components/pages/eventList/eventList.component";
import { EventListResolver } from "./resolvers/eventListResolver";
import { EventListModalComponent } from "./components/pages/eventList/eventListModal/eventListModal.component";
import { ProductService } from "./services/productService";
import { ProductResolver } from "./resolvers/productResolver";
import { ProductComponent } from "./components/pages/product/product.component";
import { ProductItemComponent } from "./components/pages/product/productItem/productItem.component";
import { ProductModalComponent } from "./components/pages/product/productModal/productModal.component";
import { ProductListItemComponent } from "./components/pages/productList/productListItem/productListItem.component";

export function createConfigService(config: ConfigService) {
    return () => config.load();
}

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule, RouterModule.forRoot(appRoutes), ModalModule.forRoot()],
    declarations: [AppComponent, ProductListComponent, ProductListModalComponent, LayoutComponent, EventListComponent,EventListModalComponent, ProductComponent, ProductItemComponent, ProductModalComponent,
        ProductListItemComponent],
    bootstrap: [AppComponent],
    providers: [ConfigService, ProductListService, ProductItemService, EventListService, ProductListResolver, EventListResolver, ProductService,ProductResolver,
        {
            provide: APP_INITIALIZER,
            useFactory: createConfigService,
            deps: [ConfigService],
            multi: true
        },
    ]
})
export class AppModule {
}
