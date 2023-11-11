<template>
  <v-container>
    <c-loader-status :loaders="{ '': [houseList.$load] }" :progressPlaceholder="false">
      <v-row>
        <v-col cols="6" v-if="house">
          <CardWithIcon :title="house.name!" icon="fas fa-house" color="purple">
            <div>Address: {{ house.address }}</div>
            <div>Main Phone: {{ house.mainPhone }}</div>
            <div>Alternate Phone: {{ house.altPhone }}</div>
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
