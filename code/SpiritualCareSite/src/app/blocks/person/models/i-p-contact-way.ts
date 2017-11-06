import { IModelBase } from '../../../models/i-model-base';

export interface IPContactWay extends IModelBase {
    Person_ID: number;
    ContactType: string;
    Value: string;
    Comment: string;
    IsDefault: Boolean;
}
