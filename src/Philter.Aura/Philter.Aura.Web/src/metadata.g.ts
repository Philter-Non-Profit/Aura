import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const AuraUser = domain.types.AuraUser = {
  name: "AuraUser",
  displayName: "Aura User",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "AuraUser",
  get keyProp() { return this.props.auraUserId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    auraUserId: {
      name: "auraUserId",
      displayName: "User ID",
      description: "Azure Object Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
        maxLength: val => !val || val.length <= 150 || "Name may not be more than 150 characters.",
      }
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      subtype: "email",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Email is required.",
        maxLength: val => !val || val.length <= 200 || "Email may not be more than 200 characters.",
        email: val => !val || /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<> ()\[\]\\.,;:\s@"]+)*)|(".+ "))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(val.trim()) || "Email must be a valid email address.",
      }
    },
    lastLogin: {
      name: "lastLogin",
      displayName: "Last Login",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
    houseManagers: {
      name: "houseManagers",
      displayName: "House Managers",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.HouseManager as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.HouseManager as ModelType).props.auraUserId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.HouseManager as ModelType).props.auraUser as ModelReferenceNavigationProperty },
      manyToMany: {
        name: "houses",
        displayName: "Houses",
        get typeDef() { return (domain.types.House as ModelType) },
        get farForeignKey() { return (domain.types.HouseManager as ModelType).props.houseId as ForeignKeyProperty },
        get farNavigationProp() { return (domain.types.HouseManager as ModelType).props.house as ModelReferenceNavigationProperty },
        get nearForeignKey() { return (domain.types.HouseManager as ModelType).props.auraUserId as ForeignKeyProperty },
        get nearNavigationProp() { return (domain.types.HouseManager as ModelType).props.auraUser as ModelReferenceNavigationProperty },
      },
      dontSerialize: true,
    },
    messages: {
      name: "messages",
      displayName: "Messages",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Message as ModelType) },
      },
      role: "value",
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const House = domain.types.House = {
  name: "House",
  displayName: "House",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "House",
  get keyProp() { return this.props.houseId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    houseId: {
      name: "houseId",
      displayName: "House Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
        maxLength: val => !val || val.length <= 200 || "Name may not be more than 200 characters.",
      }
    },
    address: {
      name: "address",
      displayName: "Address",
      type: "string",
      subtype: "multiline",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Address is required.",
        maxLength: val => !val || val.length <= 1000 || "Address may not be more than 1000 characters.",
      }
    },
    mainPhone: {
      name: "mainPhone",
      displayName: "Main Phone Number",
      description: "The main phone number to reach the house",
      type: "string",
      subtype: "tel",
      role: "value",
      rules: {
        maxLength: val => !val || val.length <= 50 || "Main Phone Number may not be more than 50 characters.",
        phone: val => !val || /^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$/.test(val.replace(/\s+/g, '')) || "Main Phone Number must be a valid phone number.",
      }
    },
    altPhone: {
      name: "altPhone",
      displayName: "Alternate Phone Number",
      description: "An alternate phone number to reach the house",
      type: "string",
      subtype: "tel",
      role: "value",
      rules: {
        maxLength: val => !val || val.length <= 50 || "Alternate Phone Number may not be more than 50 characters.",
        phone: val => !val || /^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$/.test(val.replace(/\s+/g, '')) || "Alternate Phone Number must be a valid phone number.",
      }
    },
    houseManagers: {
      name: "houseManagers",
      displayName: "House Managers",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.HouseManager as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.HouseManager as ModelType).props.houseId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.HouseManager as ModelType).props.house as ModelReferenceNavigationProperty },
      manyToMany: {
        name: "auraUsers",
        displayName: "Aura Users",
        get typeDef() { return (domain.types.AuraUser as ModelType) },
        get farForeignKey() { return (domain.types.HouseManager as ModelType).props.auraUserId as ForeignKeyProperty },
        get farNavigationProp() { return (domain.types.HouseManager as ModelType).props.auraUser as ModelReferenceNavigationProperty },
        get nearForeignKey() { return (domain.types.HouseManager as ModelType).props.houseId as ForeignKeyProperty },
        get nearNavigationProp() { return (domain.types.HouseManager as ModelType).props.house as ModelReferenceNavigationProperty },
      },
      dontSerialize: true,
    },
    rooms: {
      name: "rooms",
      displayName: "Rooms",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Room as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Room as ModelType).props.houseId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Room as ModelType).props.house as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
    houseWithRooms: {
      type: "dataSource",
      name: "HouseWithRooms",
      displayName: "House With Rooms",
      isDefault: true,
      props: {
      },
    },
  },
}
export const HouseManager = domain.types.HouseManager = {
  name: "HouseManager",
  displayName: "House Manager",
  get displayProp() { return this.props.houseManagerId }, 
  type: "model",
  controllerRoute: "HouseManager",
  get keyProp() { return this.props.houseManagerId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    houseManagerId: {
      name: "houseManagerId",
      displayName: "House Manager Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    houseId: {
      name: "houseId",
      displayName: "House Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.House as ModelType).props.houseId as PrimaryKeyProperty },
      get principalType() { return (domain.types.House as ModelType) },
      get navigationProp() { return (domain.types.HouseManager as ModelType).props.house as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => val != null || "House is required.",
      }
    },
    house: {
      name: "house",
      displayName: "House",
      type: "model",
      get typeDef() { return (domain.types.House as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.HouseManager as ModelType).props.houseId as ForeignKeyProperty },
      get principalKey() { return (domain.types.House as ModelType).props.houseId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.House as ModelType).props.houseManagers as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    auraUserId: {
      name: "auraUserId",
      displayName: "Aura User Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.AuraUser as ModelType).props.auraUserId as PrimaryKeyProperty },
      get principalType() { return (domain.types.AuraUser as ModelType) },
      get navigationProp() { return (domain.types.HouseManager as ModelType).props.auraUser as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => val != null || "Aura User is required.",
        pattern: val => !val || /^\s*[{(]?[0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}[)}]?\s*$/.test(val) || "Aura User does not match expected format.",
      }
    },
    auraUser: {
      name: "auraUser",
      displayName: "Aura User",
      type: "model",
      get typeDef() { return (domain.types.AuraUser as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.HouseManager as ModelType).props.auraUserId as ForeignKeyProperty },
      get principalKey() { return (domain.types.AuraUser as ModelType).props.auraUserId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.AuraUser as ModelType).props.houseManagers as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Message = domain.types.Message = {
  name: "Message",
  displayName: "Message",
  get displayProp() { return this.props.messageId }, 
  type: "model",
  controllerRoute: "Message",
  get keyProp() { return this.props.messageId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    messageId: {
      name: "messageId",
      displayName: "Message Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    messageBody: {
      name: "messageBody",
      displayName: "Message Body",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Message Body is required.",
        maxLength: val => !val || val.length <= 1600 || "Message Body may not be more than 1600 characters.",
      }
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Recipient = domain.types.Recipient = {
  name: "Recipient",
  displayName: "Recipient",
  get displayProp() { return this.props.recipientId }, 
  type: "model",
  controllerRoute: "Recipient",
  get keyProp() { return this.props.recipientId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    recipientId: {
      name: "recipientId",
      displayName: "Recipient Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    recipientName: {
      name: "recipientName",
      displayName: "Recipient Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Recipient Name is required.",
        maxLength: val => !val || val.length <= 150 || "Recipient Name may not be more than 150 characters.",
      }
    },
    recipientPhoneNumber: {
      name: "recipientPhoneNumber",
      displayName: "Recipient Phone Number",
      type: "string",
      subtype: "tel",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Recipient Phone Number is required.",
        maxLength: val => !val || val.length <= 150 || "Recipient Phone Number may not be more than 150 characters.",
        phone: val => !val || /^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$/.test(val.replace(/\s+/g, '')) || "Recipient Phone Number must be a valid phone number.",
      }
    },
    messages: {
      name: "messages",
      displayName: "Messages",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Message as ModelType) },
      },
      role: "value",
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Room = domain.types.Room = {
  name: "Room",
  displayName: "Room",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Room",
  get keyProp() { return this.props.roomId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    roomId: {
      name: "roomId",
      displayName: "Room Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    houseId: {
      name: "houseId",
      displayName: "House Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.House as ModelType).props.houseId as PrimaryKeyProperty },
      get principalType() { return (domain.types.House as ModelType) },
      get navigationProp() { return (domain.types.Room as ModelType).props.house as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => val != null || "House is required.",
      }
    },
    house: {
      name: "house",
      displayName: "House",
      type: "model",
      get typeDef() { return (domain.types.House as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Room as ModelType).props.houseId as ForeignKeyProperty },
      get principalKey() { return (domain.types.House as ModelType).props.houseId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.House as ModelType).props.rooms as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
        maxLength: val => !val || val.length <= 200 || "Name may not be more than 200 characters.",
      }
    },
    notes: {
      name: "notes",
      displayName: "Notes",
      type: "string",
      subtype: "multiline",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const DirectionEnum = domain.types.DirectionEnum = {
  name: "DirectionEnum",
  displayName: "Direction Enum",
  type: "object",
  props: {
  },
}
export const MessageResource = domain.types.MessageResource = {
  name: "MessageResource",
  displayName: "Message Resource",
  type: "object",
  props: {
    body: {
      name: "body",
      displayName: "Body",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    numSegments: {
      name: "numSegments",
      displayName: "Num Segments",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    direction: {
      name: "direction",
      displayName: "Direction",
      type: "object",
      get typeDef() { return (domain.types.DirectionEnum as ObjectType) },
      role: "value",
      dontSerialize: true,
    },
    from: {
      name: "from",
      displayName: "From",
      type: "object",
      get typeDef() { return (domain.types.PhoneNumber as ObjectType) },
      role: "value",
      dontSerialize: true,
    },
    to: {
      name: "to",
      displayName: "To",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    dateUpdated: {
      name: "dateUpdated",
      displayName: "Date Updated",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
      dontSerialize: true,
    },
    price: {
      name: "price",
      displayName: "Price",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    errorMessage: {
      name: "errorMessage",
      displayName: "Error Message",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    uri: {
      name: "uri",
      displayName: "Uri",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    accountSid: {
      name: "accountSid",
      displayName: "Account Sid",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    numMedia: {
      name: "numMedia",
      displayName: "Num Media",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    status: {
      name: "status",
      displayName: "Status",
      type: "object",
      get typeDef() { return (domain.types.StatusEnum as ObjectType) },
      role: "value",
      dontSerialize: true,
    },
    messagingServiceSid: {
      name: "messagingServiceSid",
      displayName: "Messaging Service Sid",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    sid: {
      name: "sid",
      displayName: "Sid",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    dateSent: {
      name: "dateSent",
      displayName: "Date Sent",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
      dontSerialize: true,
    },
    dateCreated: {
      name: "dateCreated",
      displayName: "Date Created",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
      dontSerialize: true,
    },
    errorCode: {
      name: "errorCode",
      displayName: "Error Code",
      type: "number",
      role: "value",
      dontSerialize: true,
    },
    priceUnit: {
      name: "priceUnit",
      displayName: "Price Unit",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    apiVersion: {
      name: "apiVersion",
      displayName: "Api Version",
      type: "string",
      role: "value",
      dontSerialize: true,
    },
    subresourceUris: {
      name: "subresourceUris",
      displayName: "Subresource Uris",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        // Type not supported natively by Coalesce - falling back to unknown.
        type: "unknown",
      },
      role: "value",
      dontSerialize: true,
    },
  },
}
export const PhoneNumber = domain.types.PhoneNumber = {
  name: "PhoneNumber",
  displayName: "Phone Number",
  type: "object",
  props: {
  },
}
export const StatusEnum = domain.types.StatusEnum = {
  name: "StatusEnum",
  displayName: "Status Enum",
  type: "object",
  props: {
  },
}
export const MessagingService = domain.services.MessagingService = {
  name: "MessagingService",
  displayName: "Messaging Service",
  type: "service",
  controllerRoute: "MessagingService",
  methods: {
    sendText: {
      name: "sendText",
      displayName: "Send Text",
      transportType: "item",
      httpMethod: "POST",
      params: {
        to: {
          name: "to",
          displayName: "To",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "To is required.",
          }
        },
        messagingServiceId: {
          name: "messagingServiceId",
          displayName: "Messaging Service Id",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Messaging Service Id is required.",
          }
        },
        message: {
          name: "message",
          displayName: "Message",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Message is required.",
          }
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "object",
        get typeDef() { return (domain.types.MessageResource as ObjectType) },
        role: "value",
      },
    },
    sendTextAt: {
      name: "sendTextAt",
      displayName: "Send Text At",
      transportType: "item",
      httpMethod: "POST",
      params: {
        to: {
          name: "to",
          displayName: "To",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "To is required.",
          }
        },
        messagingServiceId: {
          name: "messagingServiceId",
          displayName: "Messaging Service Id",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Messaging Service Id is required.",
          }
        },
        message: {
          name: "message",
          displayName: "Message",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Message is required.",
          }
        },
        messageTime: {
          name: "messageTime",
          displayName: "Message Time",
          type: "date",
          dateKind: "datetime",
          noOffset: true,
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "object",
        get typeDef() { return (domain.types.MessageResource as ObjectType) },
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    AuraUser: typeof AuraUser
    DirectionEnum: typeof DirectionEnum
    House: typeof House
    HouseManager: typeof HouseManager
    Message: typeof Message
    MessageResource: typeof MessageResource
    PhoneNumber: typeof PhoneNumber
    Recipient: typeof Recipient
    Room: typeof Room
    StatusEnum: typeof StatusEnum
  }
  services: {
    MessagingService: typeof MessagingService
  }
}

solidify(domain)

export default domain as unknown as AppDomain
