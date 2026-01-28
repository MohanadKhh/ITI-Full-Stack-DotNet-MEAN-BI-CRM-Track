import { Routes } from '@angular/router';
import { Products } from './components/products/products';
import { ProductDetails } from './components/product-details/product-details';
import { ProductCreation } from './components/product-creation/product-creation';
import { ProductUpdated } from './components/product-updated/product-updated';
import { About } from './components/about/about';
import { Contact } from './components/contact/contact';
import { Error } from './components/error/error';

export const routes: Routes = [
    {path: '', redirectTo: 'products', pathMatch: 'full' },
    {path: 'products', component: Products},
    {path: 'products/creation', component: ProductCreation},
    {path: 'products/:id', component: ProductDetails},
    {path: 'products/update/:id', component: ProductUpdated},
    {path: 'about', component: About},
    {path: 'contact', component: Contact},
    {path: '**', component: Error}
];