<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';

const src = ref("");
const alt = ref("");
const caption = ref("");
</script>

<template>
    <EditContainer label="Image" type="Image">
        <div class="w-full flex justify-between">
            <EditInput label="Image URL" v-model="src" />
            <EditInput label="Image Alt Text" v-model="alt" />
        </div>
        <EditInput label="Image Caption (optional)" v-model="caption" />
    </EditContainer>
</template>
