export interface IUser {
    userName: string;
    password: string;
    confirmedPassword: string;
    email: string;
    name: string;
}

export interface IUserWithAddress extends IUser {
    streetName: string;
    houseNumber: string;
    apartmentNumber: string;
}
