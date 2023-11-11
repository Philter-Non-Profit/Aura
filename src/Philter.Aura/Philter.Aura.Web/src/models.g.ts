import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface AuraUser extends Model<typeof metadata.AuraUser> {
  
  /** Azure Object Id */
  auraUserId: string | null
  name: string | null
  email: string | null
  lastLogin: Date | null
  houseManagers: HouseManager[] | null
  messages: Message[] | null
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
  houseManagers: HouseManager[] | null
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
export namespace House {
  export namespace DataSources {
    
    export class HouseWithRooms implements DataSource<typeof metadata.House.dataSources.houseWithRooms> {
      readonly $metadata = metadata.House.dataSources.houseWithRooms
    }
  }
}


export interface HouseManager extends Model<typeof metadata.HouseManager> {
  houseManagerId: number | null
  houseId: number | null
  house: House | null
  auraUserId: string | null
  auraUser: AuraUser | null
}
export class HouseManager {
  
  /** Mutates the input object and its descendents into a valid HouseManager implementation. */
  static convert(data?: Partial<HouseManager>): HouseManager {
    return convertToModel(data || {}, metadata.HouseManager) 
  }
  
  /** Maps the input object and its descendents to a new, valid HouseManager implementation. */
  static map(data?: Partial<HouseManager>): HouseManager {
    return mapToModel(data || {}, metadata.HouseManager) 
  }
  
  /** Instantiate a new HouseManager, optionally basing it on the given data. */
  constructor(data?: Partial<HouseManager> | {[k: string]: any}) {
    Object.assign(this, HouseManager.map(data || {}));
  }
}


export interface Message extends Model<typeof metadata.Message> {
  messageId: number | null
  messageBody: string | null
}
export class Message {
  
  /** Mutates the input object and its descendents into a valid Message implementation. */
  static convert(data?: Partial<Message>): Message {
    return convertToModel(data || {}, metadata.Message) 
  }
  
  /** Maps the input object and its descendents to a new, valid Message implementation. */
  static map(data?: Partial<Message>): Message {
    return mapToModel(data || {}, metadata.Message) 
  }
  
  /** Instantiate a new Message, optionally basing it on the given data. */
  constructor(data?: Partial<Message> | {[k: string]: any}) {
    Object.assign(this, Message.map(data || {}));
  }
}


export interface Recipient extends Model<typeof metadata.Recipient> {
  recipientId: number | null
  recipientName: string | null
  recipientPhoneNumber: string | null
  messages: Message[] | null
}
export class Recipient {
  
  /** Mutates the input object and its descendents into a valid Recipient implementation. */
  static convert(data?: Partial<Recipient>): Recipient {
    return convertToModel(data || {}, metadata.Recipient) 
  }
  
  /** Maps the input object and its descendents to a new, valid Recipient implementation. */
  static map(data?: Partial<Recipient>): Recipient {
    return mapToModel(data || {}, metadata.Recipient) 
  }
  
  /** Instantiate a new Recipient, optionally basing it on the given data. */
  constructor(data?: Partial<Recipient> | {[k: string]: any}) {
    Object.assign(this, Recipient.map(data || {}));
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


export interface DirectionEnum extends Model<typeof metadata.DirectionEnum> {
}
export class DirectionEnum {
  
  /** Mutates the input object and its descendents into a valid DirectionEnum implementation. */
  static convert(data?: Partial<DirectionEnum>): DirectionEnum {
    return convertToModel(data || {}, metadata.DirectionEnum) 
  }
  
  /** Maps the input object and its descendents to a new, valid DirectionEnum implementation. */
  static map(data?: Partial<DirectionEnum>): DirectionEnum {
    return mapToModel(data || {}, metadata.DirectionEnum) 
  }
  
  /** Instantiate a new DirectionEnum, optionally basing it on the given data. */
  constructor(data?: Partial<DirectionEnum> | {[k: string]: any}) {
    Object.assign(this, DirectionEnum.map(data || {}));
  }
}


export interface MessageResource extends Model<typeof metadata.MessageResource> {
  body: string | null
  numSegments: string | null
  direction: DirectionEnum | null
  from: PhoneNumber | null
  to: string | null
  dateUpdated: Date | null
  price: string | null
  errorMessage: string | null
  uri: string | null
  accountSid: string | null
  numMedia: string | null
  status: StatusEnum | null
  messagingServiceSid: string | null
  sid: string | null
  dateSent: Date | null
  dateCreated: Date | null
  errorCode: number | null
  priceUnit: string | null
  apiVersion: string | null
  subresourceUris: unknown[] | null
}
export class MessageResource {
  
  /** Mutates the input object and its descendents into a valid MessageResource implementation. */
  static convert(data?: Partial<MessageResource>): MessageResource {
    return convertToModel(data || {}, metadata.MessageResource) 
  }
  
  /** Maps the input object and its descendents to a new, valid MessageResource implementation. */
  static map(data?: Partial<MessageResource>): MessageResource {
    return mapToModel(data || {}, metadata.MessageResource) 
  }
  
  /** Instantiate a new MessageResource, optionally basing it on the given data. */
  constructor(data?: Partial<MessageResource> | {[k: string]: any}) {
    Object.assign(this, MessageResource.map(data || {}));
  }
}


export interface PhoneNumber extends Model<typeof metadata.PhoneNumber> {
}
export class PhoneNumber {
  
  /** Mutates the input object and its descendents into a valid PhoneNumber implementation. */
  static convert(data?: Partial<PhoneNumber>): PhoneNumber {
    return convertToModel(data || {}, metadata.PhoneNumber) 
  }
  
  /** Maps the input object and its descendents to a new, valid PhoneNumber implementation. */
  static map(data?: Partial<PhoneNumber>): PhoneNumber {
    return mapToModel(data || {}, metadata.PhoneNumber) 
  }
  
  /** Instantiate a new PhoneNumber, optionally basing it on the given data. */
  constructor(data?: Partial<PhoneNumber> | {[k: string]: any}) {
    Object.assign(this, PhoneNumber.map(data || {}));
  }
}


export interface StatusEnum extends Model<typeof metadata.StatusEnum> {
}
export class StatusEnum {
  
  /** Mutates the input object and its descendents into a valid StatusEnum implementation. */
  static convert(data?: Partial<StatusEnum>): StatusEnum {
    return convertToModel(data || {}, metadata.StatusEnum) 
  }
  
  /** Maps the input object and its descendents to a new, valid StatusEnum implementation. */
  static map(data?: Partial<StatusEnum>): StatusEnum {
    return mapToModel(data || {}, metadata.StatusEnum) 
  }
  
  /** Instantiate a new StatusEnum, optionally basing it on the given data. */
  constructor(data?: Partial<StatusEnum> | {[k: string]: any}) {
    Object.assign(this, StatusEnum.map(data || {}));
  }
}


