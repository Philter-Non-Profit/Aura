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
      description: "A unique user identifying GUID",
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
    managedHouses: {
      name: "managedHouses",
      displayName: "Managed Houses",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.House as ModelType) },
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
    managers: {
      name: "managers",
      displayName: "Managers",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.AuraUser as ModelType) },
      },
      role: "value",
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
      rules: {
        required: val => (val != null && val !== '') || "Notes is required.",
      }
    },
  },
  methods: {
  },
  dataSources: {
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    AuraUser: typeof AuraUser
    House: typeof House
    Room: typeof Room
  }
  services: {
  }
}

solidify(domain)

export default domain as unknown as AppDomain
