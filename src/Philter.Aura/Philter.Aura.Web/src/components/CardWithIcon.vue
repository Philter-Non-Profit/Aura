<template>
    <v-card :title="title">
        <template v-slot:prepend>
            <v-icon :icon="icon" :color="color"></v-icon>
        </template>
        <template v-slot:append>
            <slot name="button">
            </slot>
        </template>
        <v-divider />
        <v-card-text class="pt-3">
            <slot>
            </slot>
        </v-card-text>
    </v-card>
</template>

<script lang="ts" setup>
withDefaults(
    defineProps<{
        title: string;
        icon: string;
        color?: string;
    }>(),
    {
        color: "primary",
    }
);
</script>