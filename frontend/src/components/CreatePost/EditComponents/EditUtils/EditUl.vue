<script setup>
import EditInput from './EditInput.vue';

const { items } = defineProps({
    items: Array
})

const addItem = () => {
    items.value.push("");
}

</script>


<template>
    <div>
        <div class="grid grid-cols-2">
            <EditInput :v-for="items, index" label="Item: " v-model="items[index]" />
        </div>
        <button class="py-2 px-4 rounded-lg" type="button" @click="addItem">Add Item</button>
    </div>
</template>
