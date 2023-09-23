<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
// import EditUl from './EditUtils/EditUl.vue';

// const items = ref<string[]>(["", ""]);
const sectionHeader = ref("");
</script>

<template>
    <EditContainer :label="sectionHeader" type="Section Unordered list">
        <EditInput label="Section Header" v-model="sectionHeader" />
        <!-- <EditUl> -->
        <!-- </EditUl> -->
    </EditContainer>
</template>