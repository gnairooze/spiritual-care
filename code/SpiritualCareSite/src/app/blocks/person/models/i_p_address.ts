import { IModelBase } from '../../../models/i-model-base';

export interface IPAddress extends IModelBase {
    AddressType: string;
    StreetNo: string;
    StreetName: string;
    City: string;
    Governerate: string ;
    Country: string;
    FloorNo: number;
    ApartmentNo: number;
    Comment: string ;
    IsDefault: Boolean;
    GPS_Long: number;
    GPS_Lat: number;
}
