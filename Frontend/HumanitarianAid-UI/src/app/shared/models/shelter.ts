import { Person } from '.';

export class Shelter {
  id: string;
  name: string;
  address: string;
  numberOfPlaces: number;
  ownerName: string;
  ownerEmail: string;
  ownerPhone: string;
  registrationDateTime: Date;
  persons: Person[];
}
