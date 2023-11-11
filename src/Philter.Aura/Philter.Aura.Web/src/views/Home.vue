<template>
  <v-container>
    <c-loader-status :loaders="{ '': [houseList.$load] }" :progressPlaceholder="false">
      <v-row>
        <v-col cols="6" v-if="house">
          <CardWithIcon :title="house.name!" icon="fas fa-house" color="purple">
            <div class="pb-3">
              <v-icon color="purple" icon="fas fa-location-dot" start />
              <span class="font-weight-bold">Address:</span>
              {{ house.address }}
            </div>
            <div class="pb-3">
              <v-icon color="purple" icon="fas fa-mobile-screen-button" start />
              <span class="font-weight-bold">Main Phone:</span>
              {{ house.mainPhone }}
            </div>
            <div class="pb-3">
              <v-icon color="purple" icon="fas fa-mobile-screen-button" start />
              <span class="font-weight-bold">Alternate Phone:</span>
              {{ house.altPhone }}
            </div>
          </CardWithIcon>
        </v-col>
        <v-col cols="8" v-else>
          <v-row>
            <v-col cols="6">
              <CardWithIcon title="Create A Home" icon="fas fa-house" color="grey">
                <template #default>
                  <EditHouseForm />
                </template>
              </CardWithIcon>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
      <v-row class="mt-4">
        <v-col cols="12" class="text-h6 pb-0">
          Rooms
        </v-col>
        <v-col cols="12"><v-divider /></v-col>
        <v-col cols="4" v-for="room in house.rooms" v-if="house.rooms">
          <RoomCard :room="room" color="purple" />
        </v-col>
        <v-col cols="12" class="font-italic text-medium-emphasis">
          No rooms
        </v-col>
      </v-row>
    </c-loader-status>
  </v-container>
</template>

<script setup lang="ts">
import { HouseListViewModel } from "@/viewmodels.g";

useTitle("Home");

const houseList = new HouseListViewModel();
houseList.$pageSize = 100;
houseList.$load();

const house = computed(() => houseList?.$items[0]);

</script>
