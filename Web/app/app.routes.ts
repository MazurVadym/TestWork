import { Routes } from '@angular/router';
import { ProductListComponent } from "./components/pages/productList/productList.component";
import { LayoutComponent } from "./components/layout/layout.component";
import { ProductListResolver } from "./resolvers/productListResolver";
import { EventListComponent } from "./components/pages/eventList/eventList.component";
import { EventListResolver } from "./resolvers/eventListResolver";
import { ProductComponent } from "./components/pages/product/product.component";
import { ProductResolver } from "./resolvers/productResolver";
/**
 * Created by Vadym on 6/28/2017.
 */

export const appRoutes: Routes = [

    {
        path: "",
        component: LayoutComponent,
        children: [
            {
                path: "eventList",
                component: EventListComponent,
                resolve: {
                    eventLists: EventListResolver,
                    productLists: ProductListResolver
                }
            },
            {
                path: "productList",
                component: ProductListComponent,
                resolve: {
                    productLists: ProductListResolver
                }
            },
            {
                path: "product",
                component: ProductComponent,
                resolve: {
                    products: ProductResolver,
                    productLists: ProductListResolver
                }
            },

            { path: "**", redirectTo: '/eventList' }
        ]
    }

];