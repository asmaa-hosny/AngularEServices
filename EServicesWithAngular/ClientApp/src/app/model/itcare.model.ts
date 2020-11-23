import { BaseModel } from "./base-model";

export class ITCareViewModel extends BaseModel {
    categories;
    selectedCategory;

    subcategories;
    selectedSubCategory;

    items;
    selectedItem;
    isERP = "false"; ;
    
}