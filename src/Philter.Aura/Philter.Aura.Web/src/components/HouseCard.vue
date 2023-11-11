<template>
    <CardWithIcon :title="house.name!" icon="fas fa-house" :color="color">
        <template #button>
            <v-btn :color="color" density="comfortable" icon="fas fa-pencil" variant="tonal" />
        </template>
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
</template>

<script lang="ts" setup>
import { HouseViewModel } from "@/viewmodels.g";
withDefaults(
    defineProps<{
        house: HouseViewModel;
        color?: string;
    }>(),
    {
        color: "primary",
    }
);
</script>