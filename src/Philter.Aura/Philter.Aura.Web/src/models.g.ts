import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface AuraUser extends Model<typeof metadata.AuraUser> {
  
  /** A unique user identifying GUID */
  auraUserId: string | null
  name: string | null
  email: string | null
  lastLogin: Date | null
  managedHouses: House[] | null
}
export class AuraUser {
  
  /** Mutates the input object and its descendents into a valid AuraUser implementation. */
  static convert(data?: Partial<AuraUser>): AuraUser {
    return convertToModel(data || {}, metadata.AuraUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid AuraUser implementation. */
  static map(data?: Partial<AuraUser>): AuraUser {
    return mapToModel(data || {}, metadata.AuraUser) 
  }
  
  /** Instantiate a new AuraUser, optionally basing it on the given data. */
  constructor(data?: Partial<AuraUser> | {[k: string]: any}) {
    Object.assign(this, AuraUser.map(data || {}));
  }
}


export interface House extends Model<typeof metadata.House> {
  houseId: number | null
  name: string | null
  address: string | null
  
  /** The main phone number to reach the house */
  mainPhone: string | null
  
  /** An alternate phone number to reach the house */
  altPhone: string | null
  managers: AuraUser[] | null
  rooms: Room[] | null
}
export class House {
  
  /** Mutates the input object and its descendents into a valid House implementation. */
  static convert(data?: Partial<House>): House {
    return convertToModel(data || {}, metadata.House) 
  }
  
  /** Maps the input object and its descendents to a new, valid House implementation. */
  static map(data?: Partial<House>): House {
    return mapToModel(data || {}, metadata.House) 
  }
  
  /** Instantiate a new House, optionally basing it on the given data. */
  constructor(data?: Partial<House> | {[k: string]: any}) {
    Object.assign(this, House.map(data || {}));
  }
}


export interface Room extends Model<typeof metadata.Room> {
  roomId: number | null
  houseId: number | null
  house: House | null
  name: string | null
  notes: string | null
}
export class Room {
  
  /** Mutates the input object and its descendents into a valid Room implementation. */
  static convert(data?: Partial<Room>): Room {
    return convertToModel(data || {}, metadata.Room) 
  }
  
  /** Maps the input object and its descendents to a new, valid Room implementation. */
  static map(data?: Partial<Room>): Room {
    return mapToModel(data || {}, metadata.Room) 
  }
  
  /** Instantiate a new Room, optionally basing it on the given data. */
  constructor(data?: Partial<Room> | {[k: string]: any}) {
    Object.assign(this, Room.map(data || {}));
  }
}


